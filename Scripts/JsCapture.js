function uploadFile()
{
    $("#load").show();
    var fd=new FormData(); 
    var count=document.getElementById('fileToUpload').files.length;     
    for(var index=0;index<count;index++) 
    {
        var file = document.getElementById('fileToUpload').files[index]; 
        fd.append(file.name, file); 
    } 
    var xhr = new XMLHttpRequest();     
    xhr.addEventListener("load", uploadComplete, false);   
    xhr.open("POST", "savetofile.aspx"); 
    xhr.send(fd);    
}

function uploadComplete(evt) {         
    window.location = "QRParser.aspx";
}
 