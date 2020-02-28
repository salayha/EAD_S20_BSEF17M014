<?php require('conn.php'); ?>
<?php
session_start();
$_SESSION["user"]=null ?>
<?php
if (isset($_REQUEST["action"]) && !empty($_REQUEST["action"]))
{
    $action=$_REQUEST["action"];
    if ($action=="Checklogin")
    {
        $usr= $_REQUEST["uname"];
        $pas= $_REQUEST["pass"];
        $sql="Select * from userinfo where Username='$usr' and Password='$pas'";
        $result=mysqli_query($conn,$sql);
        $recordsFound=mysqli_num_rows($result);
        $val;
        if ($recordsFound)
        {
            $val="true";
            $_SESSION["user"]=$usr;
        }
        else{
            $val="false";
        }
        echo json_encode($val);
    }
    if ($action=="doSignup")
    {
        $usr= $_REQUEST["uname"];
        $pas= $_REQUEST["pass"];
        $name= $_REQUEST["name"];
        $confirm= $_REQUEST["conf"];
        $val;
        if ($pas==$confirm)
        {
            $_SESSION["user"]=$usr;
            $sql="Insert into userinfo (Name,Username,Password) Values ('$name','$usr','$pas')";
            mysqli_query($conn,$sql);
            $val="true";
         }
         else{
            $val="false";
         }
         echo json_encode($val);
    }
}
?>