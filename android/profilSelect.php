<?php
include('connection.php');

$sql="select Nume,Prenume,Tara from VoluntariProfil"; //comanda scrisa in sql to obtain data
if ($connect -> connect_errno) {
    echo "Failed to connect to MySQL|hu; ";// . $connect -> connect_error;
    exit();
}
$result=mysqli_query($connect, $sql);//aplicam comanda
if($result)
{
if(mysqli_num_rows($result)>0){
    while($row=mysqli_fetch_assoc($result)){
        echo "Nume:".$row['Nume']."|Prenume:".$row['Prenume']."|Tara:".$row['Tara'].";";
    }
}
}
else
{
    echo "no connecttion|rt;";
}
?>