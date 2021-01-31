<?php

	require("connection.php");
	
	$query = "UPDATE `tables` ".
			"SET is_occupied = 0";

	echo $query;
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	echo "1: SQL query successsed";	
?>
