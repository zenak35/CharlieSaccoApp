<?php

mysql_connect("localhost","root");
//connect to your db
mysql_select_db("savings");
//get id entered by user
$id=$_POST['id'];

$res=mysql_query
("SELECT*FROM `members` 
WHERE id='$id'");
//check empty results

while($colms = mysql_fetch_row($res))
{
//return collumns
echo "ID:".$colms[0];
print "\n";
echo "Amount: ".$colms[1];
print "\n";
echo "Full Names: ".$colms[2];
}//end while loop

?>