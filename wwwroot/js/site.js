// Write your JavaScript code.

var pusher = new Pusher('<PUSHER_APP_KEY>', {
    cluster: 'eu', 
    encrypted: true
 });

 let channel = pusher.subscribe('coll-text-editor');
 
let timeout = null;
// Sends the text to the server which in turn is sent to Pusher's server
$("#editor").keyup(function () {
   let Content = $("#editor").text();
    clearTimeout(timeout);
    timeout = setTimeout(function() {
         $.post("/Pen/ContentChange", { Content: Content, penId: $("#penId").val(), sessionID: pusher.sessionID})
    }, 300);
});

channel.bind('contentChange', function(data) {
    if ( (data.sessionID != pusher.sessionID) && (data.penId == $("#penId").val()) ) {
       $("#editor").text(data.Content)
    }
 });


channel.bind('newPen', function(data) {
    if (data.sessionID != pusher.sessionID) {
        $("#Pen").append(
            `
             <div class="pen">
                <a class="" href="/Pen/Index/${data.penId}"> 
                   ${data.Title}
                </a>
             </div>
           `
       )
    }
  });