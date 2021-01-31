<?php


	require("connection.php");
	
	$query = "INSERT INTO `orders` ".
			"(is_done, is_finished, waiter_id, dish_id, table_id) ".
			"VALUES ".
			"(0,0,0,0,0)";
	
	echo $query . "<br>";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	if(mysqli_num_rows($queryResult) == 0)
	{
		echo "3: Not exists";
		exit();
	}
?>
