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
<?php
    /*
    if (isset($_REQUEST["btn"]))
    {
        $usr=$_REQUEST["usr_name"];
        $pass=$_REQUEST["usr_pass"];
        $sql="Select * from userinfo where Username='$usr' and Password='$pass'";
        $result=mysqli_query($conn,$sql);
        $recordsFound=mysqli_num_rows($result);
        if ($recordsFound==1)
        {
            $_SESSION["user"]=$_REQUEST["usr_name"];
            header('Location:home.php');
        }
        else{
            $_SESSION["user"]=null;
            $error="**Invalid Username or Password**";
        }
    }*/

?>
<script>
$(document).ready(function()
{
    
    $("#btn-login").click(function()
    {
        var a=$("#user").val();
         var b=$("#pswd").val();
        var dataToSend={"action":"Checklogin","uname":a,"pass":b};
        var settings={
            type:"post",
            dataType:"json",
            url:"api.php",
            data:dataToSend,
            success: myFunction,
            error: OnError 
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
            $("#err").text("**Invalid Username or Password**");
        }
    }
});
</script>
<div class="container">
<div id="myform">

<div class="row">
<div class="col-3">
Username: </div>
<div class="col-4">
<input type="text" id="user" class="inp" name="usr_name" required="required"> <br/> </div>
</div>
<div class="row">
<div class="col-3">
Password: 
</div>
<div class="col-4">
<input type="password" id="pswd" class="inp" name="usr_pass" required="required"> <br/> </div>
</div>
<div class="row">
<div class="col-10">
<button id="btn-login" name="btn"  style="margin-top:20px;" class="btn btn-lg btn-primary btn-block" >Log in</button> </div>
</div>
<div class="row">
<div class="col-10">
<h5 id="err" style="color:red;"></h5>;
 </div> </div>
<div class="row">
<div class="col-10">
<form action="signup.php">
<button id="signUp"  type="submit" class="btn btn-lg btn-primary btn-block">
Tap to Sign Up
</button> </form> </div>
</div>
</div>
</div>
</body>
</html>