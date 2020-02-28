<?php
    session_start();
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
    if ((isset($_SESSION["user"]))==false)
    {
        header('Location:login.php');
    }
 ?>
<h1 id="myform">
Welcome to your account " <?php echo $_SESSION["user"];?> " </h1>
</body>
</html>