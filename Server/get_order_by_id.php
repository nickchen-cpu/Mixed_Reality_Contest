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
	$query = "SELECT * FROM `orders` WHERE `id` = '{$order_id}' ";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	if(mysqli_num_rows($queryResult) == 0)
	{
		echo "3: Not exists";
		exit();
	}
	
	
	$row = mysqli_fetch_assoc($queryResult);
	
	$result = array('id' => $row['id'], 'is_done' => $row['is_done'], 'is_finished'=> $row['is_finished'], 'waiter_id' => $row['waiter_id'], 'dish_id' => $row['dish_id'], 'table_id' => $row['table_id'], 'time' => $row['time']);

	// get comments on message board


	echo json_encode($result);	
?>
