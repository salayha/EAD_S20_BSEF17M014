<?php require('conn.php'); ?>
<?php
    session_start();
    $_SESSION["pid"]=null;
?>
<script> let id=0; </script>
<html>
<head>
<script src="jquery.js"> </script>
<link rel="stylesheet" type="text/css" href="home2.css">
<meta name="viewport" content="width=device-width, initial-scale=1">
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
</head>
<body>
 <?php
    if ((isset($_SESSION["user"]))==false)
    {
        header('Location:login.php');
    }

 ?>
 <script>
$(document).ready(function() 
{ 
  var dataToSend={"action":"displayRoots", "parent":id};
    var settings={
    type:"post",
    dataType:"json",
    url:"api.php",
    data:dataToSend,
    success: myMainFunction,
    error: OnError 
    }
        $.ajax(settings);
        console.log("sent");
        return false;
   });
   function OnError()
    {
        console.log("err");
        alert("error occured");
    }
    function myMainFunction(r)
  {
    for (var i=0;i<r.data.length;i++)
    {
      var obj=r.data[i];
      var div= $("<div></div>").addClass('item').text(obj.FolderName).attr("fid",obj.FolderId);
      $(".menu").append(div);
    }
  //function for making new folder
  $("#new").click(function() {
    
    $("#hid").attr("type","text");

  });
  $("#btn-hid").click(function() {
    let a=$("#hid").val();
   if (a!="")
   {
    $("#errName").text("");
    var dataToSend={"action":"makeNew","fname":a, "parent":id};
    var settings={
    type:"post",
    dataType:"json",
    url:"api.php",
    data:dataToSend,
    success: myFunction,
    error: OnError 
    }
        $.ajax(settings);
        console.log("sent");
        return false;
   }
   else{
     $("#errName").text("Please enter a name.");
   }
   
   });
    function myFunction(r)
    {
      if (r["fid"]==-1)
      {
        $("#errName").text("A folder with this name already exists.");
        $("#hid").val("");
      } 
      else
      {
        $("#errName").text("");
        let a=$("#hid").val();
        $("#hid").attr("type","hidden");
        var div= $("<div></div>").addClass('item').text(a).attr("fid",r["fid"]);
        $(".menu").append(div);
        $("#hid").val("");
      }
      $('.item').click(function()
     {
      id= $(this).attr("fid");
      $('.item').remove();
      var dataToSend={"action":"displayRoots", "parent":id};
      var settings={
      type:"post",
      dataType:"json",
      url:"api.php",
      data:dataToSend,
      success: myMainFunction,
      error: OnError 
    }
        $.ajax(settings);
        console.log("sent");
        return false;
   });
    }
    $('.item').click(function()
     {
      id= $(this).attr("fid");
      $('.item').remove();
      var dataToSend={"action":"displayRoots", "parent":id};
      var settings={
      type:"post",
      dataType:"json",
      url:"api.php",
      data:dataToSend,
      success: myMainFunction,
      error: OnError 
    }
        $.ajax(settings);
        console.log("sent");
        return false;
   });
}
</script>
<div id="welcome">
Welcome to your account " <?php echo $_SESSION["user"];?> "
 </div>
 <div id="new" fid="" pid="" fname=""> New folder'+'
     <input id="hid" type="hidden" value="" placeholder="folderName"/> 
 </div>
  <button id="btn-hid" style="width:30%"> create </button>
  <h5 id="errName" style="color:red; font-style:italic" ></h5>
 <div class='menu-container'>
      <div class='menu'>
        
      </div>
    </div>


     
</body>
</html>