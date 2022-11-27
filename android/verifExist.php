<?php
include('connection.php');

$email=$_POST['verifEmail'];

$sql="select * from VoluntariProfil where Email='".$email."'"; //comanda scrisa in sql to obtain data
if ($connect -> connect_errno) {
    echo "Failed to connect to MySQL;";// . $connect -> connect_error;
    exit();
}
$result=mysqli_query($connect, $sql);//aplicam comanda
if($result)
{
    if(mysqli_num_rows($result)>0)
        echo "da";
    else
        echo "nu";
}
else
{
    echo "no connecttion|rt;";
}
?>