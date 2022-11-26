<?php
include('connection.php');



$sql="select Categorie,Locatie,Area,Descriere,Area,LinkSite,NrVoluntari,Desfasurare,Organizatori,Asociatie,Voluntari
     from VoluntariEvent where Categorie=\""; //comanda scrisa in sql to obtain data
//$nr=$_POST['addNr'];
//$sql.="'Strans Gunoaie'";
$sql=$sql.$_POST['da'];
$sql.="\"";
//for($x=2;$x<=$nr;$x++)
//{
//    $sql=$sql." or Categorie=";
//    $local=$_POST['"add"+$x+"'];
//    $sql=$sql.$local;
//}
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
    else
    echo "nodata";
}
else
{
    echo "no connecttion|rt;";
}
?>