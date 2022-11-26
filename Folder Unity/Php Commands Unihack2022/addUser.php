<?php
include('connection.php');

//din C# trimitem un WWWForm cu niste "date globale" si cand se compileaza ce
//era pe URL, prin $_POST['dnfv'] se acceseaza acea valoare globala dnfv daca exista
$nume=$_POST['addNume'];
$prenume=$_POST['addPrenume'];
$email=$_POST['addEmail'];
$parola=$_POST['addParola'];
$nrTel=$_POST['addNrTel'];
$tara=$_POST['addTara'];
$judet=$_POST['addJudet'];
$oras=$_POST['addOras'];
$interese=$_POST['addInterese'];

$sql="insert into VoluntariProfil (Nume,Prenume,Email,Parola,NrTel,Tara,Judet,Oras,Interese) values 
('".$nume."','".$prenume."','".$email."','".$parola."','".$nrTel."','".$tara."','".$judet."','".$oras."','".$interese."')";
$result=mysqli_query($connect,$sql);

?>