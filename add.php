
<?php

$id=$_POST['id'];
$name=$_POST['name'];
$amount=$_POST['amount'];
//save in MYSQL db
//connect to mysql server
mysql_connect("localhost","root");
//connect to your db
mysql_select_db("savings");
//add the 3 variables
$result=mysql_query("INSERT INTO members
(id,names,amount)VALUES('$id','$name','$amount')");

//check true/false query execution
if($result)
{
echo "1";//1 for success
}
else {
echo "0";//0 for fail
}

?>









