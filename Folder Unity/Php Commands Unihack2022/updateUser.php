<?php
include('connection.php');

$email=$_POST['editEmail'];
$parola=$_POST['editParola'];
$whereField=$_POST['whereField'];
$whereCondition=$_POST['whereCondition'];

$sql="update VoluntariProfil set email='".$email."',parola='".$parola."' where ".$whereField."='".$whereCondition."'";
mysqli_query($connect,$sql);

?>