<?php
include('connection.php');

$sql="select Categorie,Locatie,Area,Descriere,LinkSite,NrVoluntari,Desfasurare,Organizatori,Asociatie,Voluntari
from VoluntariEvent"; //comanda scrisa in sql to obtain data
if ($connect -> connect_errno) {
    echo "Failed to connect to MySQL|hu; ";// . $connect -> connect_error;
    exit();
}
$result=mysqli_query($connect, $sql);//aplicam comanda
if($result)
{
    if(mysqli_num_rows($result)>0)
    {
        while($row=mysqli_fetch_assoc($result))
        {
            echo "Categorie:".$row['Categorie']."|Locatie:".$row['Locatie']."|Area:".$row['Area'].
            "|Descriere:".$row['Descriere']."|LinkSite:".$row['LinkSite']."|NrVoluntari:".$row['NrVoluntari'].
            "|Desfasurare:".$row['Desfasurare']."|Organizatori:".$row['Organizatori']."|Asociatie:".$row['Asociatie'].
            "|Voluntari:".$row['Voluntari'].";";
        }
    }
}
else
{
    echo "no connecttion|rt;";
}
?>