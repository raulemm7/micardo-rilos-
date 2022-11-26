<?php
include('connection.php');

$email=$_POST['verifEmail'];
$parola=$_POST['verifParola'];

$sql="select * from VoluntariProfil where Email='".$email."'  and Parola='".$parola."'"; //comanda scrisa in sql to obtain data
if ($connect -> connect_errno) {
    echo "Failed to connect to MySQL;";// . $connect -> connect_error;
    exit();
}
$result=mysqli_query($connect, $sql);//aplicam comanda
if($result)
{
    if(mysqli_num_rows($result)>0)
    {
        echo "ok";
        //while($row=mysqli_fetch_assoc($result)){
        //    echo "Nume:".$row['Nume']."|Prenume:".$row['Prenume']."|Tara:".$row['Tara'].";";
       // }
    }
    else
    echo "incorrect";
}
else
{
    echo "no connecttion|rt;";
}
?>