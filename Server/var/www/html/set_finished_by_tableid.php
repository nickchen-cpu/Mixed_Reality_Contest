<?php
	/*
 	*  Input: id of target order 
	*  Output: dishes name, positive vote, negative vote, calorie, comments on message board
	*/

	require("connection.php");
	$table_id = intval($_POST["table_id"]);
	if ($table_id <= 0)
	{
		die("Order ID Error");
	}
	
	// get name, calorire, pos vote, neg vote
	$query = "UPDATE `orders` SET `is_finished` = 1 WHERE `table_id` = '{$table_id}'";	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	echo 0;	
?>
