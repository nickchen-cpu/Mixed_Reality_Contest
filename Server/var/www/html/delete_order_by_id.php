<?php
	/*
 	*  Input: id of target order 
	*  Output: dishes name, positive vote, negative vote, calorie, comments on message board
	*/

	require("connection.php");
	$order_id = intval($_POST["order_id"]);
	if ($order_id <= 0)
	{
		die("Order ID Error");
	}
	
	// get name, calorire, pos vote, neg vote
	$query = "DELETE FROM `orders` WHERE `id` = '{$order_id}' ";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	echo 0;	
?>
