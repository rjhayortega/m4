<?php
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



$sql = "";
$s = $_GET["s"];
$p = $_GET["p"];

if($s){

$sql = "SELECT * FROM segments where id='".$s."'";
$result = $conn->query($sql);
$cmd = "";

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      $cmd = $row["cmd"];
    }

  }

$sql = "SELECT * FROM mailList where ".$cmd;

}


if($p){
  $sql = "SELECT * FROM mailList where location='$p' ";
}

if(!$p && !$s){
$sql = "SELECT * FROM mailList ";

}


$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        $name = $row["name"];
        $email = $row["email"];
        $loc = $row["location"];
        $c = $row["county"];
        $ip = $row["is_pregnant"];
        $md = $row["months_due"];
        $pdd = $row["pregnancy_due_date"];
        $noc = $row["number_of_children"];
        $jd = $row["joinedDate"];
        $p = $row["pampers"];
        $h = $row["huggies"];
        $o =  $row["other"];
        $ob = $row["ownbrand"];
        $ac = $row["area_code"];
        $ph = $row["phone_number"];
        $visits = $row["visits"];
        $source = $row["source"];

        $c1 = "";
        $c2 = "";
        $c3 = "";
        $c4 = "";

        if(strlen( $row["child1"])>0){
          $c1 = $row["child1"];
            $c1tmp = explode("-",$c1);
        $c1 = $c1tmp[1]."/".$c1tmp[0];
        }


        if(strlen($row["child2"])>0){
          $c2 = $row["child2"];
             $c2tmp = explode("-",$c2);
        $c2 = $c2tmp[1]."/".$c2tmp[0];
        
        }

        if(strlen($row["child3"])>0){
        $c3 = $row["child3"];
          $c3tmp = explode("-",$c3);
        $c3 = $c3tmp[1]."/".$c3tmp[0];
        }
       
     if(strlen($row["child4"])>0){
       
        $c4 = $row["child4"];
        $c4tmp = explode("-",$c4);
        $c4 = $c4tmp[1]."/".$c4tmp[0];
        
    }

  echo "<tr><td>".$name."</td><td>".$email."</td><td>".$jd."</td><td>".$source."</td><td>".$loc."</td><td>".$c."</td><td>".$ip."</td>
  <td>".$pdd."</td><td>".$md."</td><td>".$noc."</td><td width=300>".$c1."</td><td>".$c2."</td><td>".$c3."</td><td>".$c4."</td><td>".$p."</td><td>".$h."</td><td>".$o."</td><td>".$ob."</td><td>".$ac."</td><td>".$ph."</td><td>".$visits."</td></tr>";

    }
} else {
    echo "0 results";

}



?>