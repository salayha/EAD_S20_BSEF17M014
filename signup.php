<?php require('conn.php'); ?>
<?php
session_start();
$_SESSION["user"]=null;
?>
<html>
<head>
<script src="jquery.js"> </script>
<link rel="stylesheet" type="text/css" href="styles.css">
<meta name="viewport" content="width=device-width, initial-scale=1">
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
</head>
<body>
<script>
$(document).ready(function()
{
    
    $("#btn-signup").click(function()
    {
        var a=$("#user").val();
         var b=$("#pswd").val();
         var d=$("#name").val();
         var c=$("#conf_pswd").val(); 
         if (a=="" || b=="" || c=="" || d=="")
         {
            if (a=="")
            {
                $("#errUsr").text("This field can't be empty");
            }
            else
            {
                $("#errUsr").text("");
            }
            if (b==""){
                $("#errPas").text("This field can't be empty");
            }
            else{
                $("#errPas").text("");
            }
            if (c=="")
            {
                $("#errConf").text("This field can't be empty");
            }
            else
            {
                $("#errConf").text("");
            }
            if (d=="")
            {
                $("#errName").text("This field can't be empty");
            }
            else
            {
                $("#errName").text("");
            }
         }
         else
         {
            
            var dataToSend={"action":"doSignup","uname":a,"pass":b, "conf":c,"name":d};
            var settings={
            type:"post",
            dataType:"json",
            url:"api.php",
            data:dataToSend,
            success: myFunction,
            error: OnError 
            }
        };
        $.ajax(settings);
        console.log("sent");
        return false;
    });
    function OnError()
    {
        console.log("err");
        alert("error occured");
    }
    function myFunction(r)
    {
        if (r=="true")
        {
            console.log("welcome");
            window.location.href="home.php"
        }
        else if(r=="false") {
            $("#err").text("**Both passwords don't match**");
        }
    }
});

</script>
<div class="container">
<div id="myform">

<div class="row">
<div class="col-3">
Name: </div>
<div class="col-4">
<input type="text" id="name" class="inp" name="_name" value="" required="required"> <br/> </div>
</div>
<div class="row">
<div class="col-10">
<h5 id="errName" style="color:red; font-style:italic" ></h5>
 </div> </div>
<div class="row">
<div class="col-3">
Username: </div>
<div class="col-4">
<input type="text" id="user" class="inp" name="usr_name" value="" required="required"> <br/> </div>
</div>
<div class="row">
<div class="col-10">
<h5 id="errUsr" style="color:red;  font-style:italic;"></h5>
 </div> </div>
<div class="row">
<div class="col-3">
Password: 
</div>
<div class="col-4">
<input type="password" id="pswd" class="inp" value="" name="usr_pass" required="required"> <br/> </div>
</div>
<div class="row">
<div class="col-10">
<h5 id="errPas" style="color:red;  font-style:italic;"></h5>
 </div> </div>
<div class="row">
<div class="col-3">
Re-enter Password: 
</div>
<div class="col-4">
<input type="password" id="conf_pswd" class="inp" value="" name="usr_conf_pass" required="required"> <br/> </div>
</div>
<div class="row">
<div class="col-10">
<h5 id="errConf" style="color:red; font-style:italic;"></h5>
 </div> </div>

<div class="row">
<div class="col-10">
<button id="btn-signup" name="btn"  style="margin-top:20px;" class="btn btn-lg btn-primary btn-block" >Sign Up</button> </div>
</div>
<div class="row">
<div class="col-10">
<h5 id="err" style="color:red;"></h5>
 </div> </div>
</div>
</div>
</body>
</html>