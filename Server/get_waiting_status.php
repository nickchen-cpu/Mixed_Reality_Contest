<?php
	/*
 	*  Input: id of target order 
	*  Output: dishes name, positive vote, negative vote, calorie, comments on message board
	*/

	require("connection.php");
	$id = intval($_POST["id"]);
	if ($order_id <= 0)
	{
		die("Order ID Error");
	}
	
	// get name, calorire, pos vote, neg vote
	$query = "SELECT * FROM `tables` WHERE `id` = '{$id}' ";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	if(mysqli_num_rows($queryResult) == 0)
	{
		echo "3: Not exists";
		exit();
	}
	
	
	$row = mysqli_fetch_assoc($queryResult);
	
	$result = array('id' => $row['id'], 'is_waiting_water' => $row['is_waiting_water'], 'is_waiting_waiter'=> $row['is_waiting_waiter']);

	// get comments on message board


	echo json_encode($result);	
?>
