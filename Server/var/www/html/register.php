<?php
	$con = mysqli_connect('localhost', 'root', 'abc@123', 'unityaccess');
	//check that connection happened
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed ";
		exit();
	}
	$username = $_POST["name"];
	$password = $_POST["password"];

/*	$username = "test1";
$password = "test2";*/
	//check if name exist
	$namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";
	
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");
	if(mysqli_num_rows($namecheck) > 0)
	{
		echo "3: Name already exists";
		exit();
	}
	$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
	$hash = crypt($password, $salt);
	$insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
	echo($insertuserquery);
	mysqli_query($con, $insertuserquery) or die("4: Insert player query failed");
	echo("0");
?>
