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
    if ($action=="makeNew")
    {
        $name=$_REQUEST["fname"];
        $parent= $_REQUEST["parent"];
        $sql= "Select FolderId from folders where FolderName='$name' and ParentID='$parent'";
        $result= mysqli_query($conn,$sql);
        $recordsFound=mysqli_num_rows($result);
        $output;
        if ($recordsFound==0)
        {
            $sql="Insert into folders (FolderName,ParentID) Values ('$name','$parent')";
            mysqli_query($conn,$sql);
            $sql= "Select FolderId from folders where FolderName='$name' and ParentID='$parent'";
            $result= mysqli_query($conn,$sql);
            $row=mysqli_fetch_assoc($result);
            $output= array("fid"=> $row["FolderId"] );
        }
        else{
            $output= array("fid"=> -1 );
        }
        echo json_encode($output);
    }
    if ($action=="displayRoots")
    {
        $pid=$_REQUEST["parent"];
        $sql= "Select * from folders where ParentID='$pid'";
        $result= mysqli_query($conn,$sql);
        $recordsFound=mysqli_num_rows($result);
        $results=array();
        if ($recordsFound>0)
        {
            while ($row=mysqli_fetch_assoc($result))
            {
                $results[]=$row;
            }
        }
        $output["data"]=$results;
        echo json_encode($output);
    }
    if ($action=="displayChilds")
    {
        $pid=$_REQUEST["parent"];
        $sql= "Select * from folders where ParentID='$pid'";
        $result= mysqli_query($conn,$sql);
        $recordsFound=mysqli_num_rows($result);
        $results=array();
        if ($recordsFound>0)
        {
            while ($row=mysqli_fetch_assoc($result))
            {
                $results[]=$row;
            }
        }
        $output["data"]=$results;
        echo json_encode($output);
    }
}
?>