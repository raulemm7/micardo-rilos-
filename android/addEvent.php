<?php
include('connection.php');

//din C# trimitem un WWWForm cu niste "date globale" si cand se compileaza ce
//era pe URL, prin $_POST['dnfv'] se acceseaza acea valoare globala dnfv daca exista
$categorie=$_POST['addCategorie'];
$locatie=$_POST['addLocatie'];
$area=$_POST['addArea'];
$descriere=$_POST['addDescriere'];
$linksite=$_POST['addLinksite'];
$nrvoluntari=$_POST['addNrvoluntari'];
$desfasurare=$_POST['addDesfasurare'];
$organizatori=$_POST['addOrganizatori'];
$asociatie=$_POST['addAsociatie'];
$voluntari=$_POST['addVoluntari'];

$sql="insert into VoluntariEvent (Categorie,Locatie,Area,Descriere,LinkSite,NrVoluntari,Desfasurare,Organizatori,Asociatie,Voluntari) values 
('".$categorie."','".$locatie."','".$area."','".$descriere."','".$linksite."','".$nrvoluntari."','".$desfasurare."','".$organizatori."','".$asociatie."','".$voluntari."')";
$result=mysqli_query($connect,$sql);

?>