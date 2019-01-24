<?php


$json = file_get_contents('php://input');
$obj = json_decode($json);


$servername = "database4.lcn.com";
$username = "LCN405272_admin";
$password = "!devadmin0987";
$dbname = "tenaciousengagement_com_admin";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 


$sql = "delete from mailList where id>0";

if ($conn->query($sql) === TRUE) {
   // echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}


//var_dump($obj);



for($i=0; $i<count($obj); $i++)
{

echo $obj[$i]->name;
$p = "";
$h = "";
$o = "";
$ob = "";

$cc = explode(",",$obj[$i]->brand_of_nappies);

foreach($cc as $c){
	if($c=="Pampers"){
		$p = "Pampers";
	}
if($c=="Huggies"){
		$h = "Huggies";
	}if($c=="Other"){
		$o = "Other";
	}if($c=="Own Brand"){
		$ob = "Own Brand";
	}
}




$sql = "INSERT INTO mailList (name,email,location,county,is_pregnant,pregnancy_due_date,number_of_children,child1,child2,child3,child4,months_due,pampers,huggies,other,own_brand,area_code,phone_number,visits,joinedDate,source)
VALUES ('".$obj[$i]->name."','".$obj[$i]->email."','".$obj[$i]->location."','".$obj[$i]->county."','".$obj[$i]->is_pregnant."'
,'".$obj[$i]->pregnancy_due_date."','".$obj[$i]->number_of_children."',
'".$obj[$i]->child1."','".$obj[$i]->child2."','".$obj[$i]->child3."','".$obj[$i]->Child4."','".(int)$obj[$i]->Months."','".$p."','".$h."','".$o."','".$ob."','".$obj[$i]->area_code."','".$obj[$i]->phone_number."','".(int)$obj[$i]->visits."','".$obj[$i]->joinedDate."','".$obj[$i]->source."')";

if ($conn->query($sql) === TRUE) {
    echo $obj[$i]->email;
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

}


$conn->close();


?>