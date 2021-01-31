<?php
	/*
 	*  Input: id of target dish 
	*  Output: Nothing
	*/

	require("connection.php");
	
	$table_id = intval($_POST["table_id"]);
	if ($table_id <= 0)
	{
		die("Table ID Error");
	}

	// get name, calorire, pos vote, neg vote
	$query = "UPDATE `tables` SET `is_waiting_waiter` = 0  WHERE `id` = '{$table_id}'";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	echo true;	
?>
