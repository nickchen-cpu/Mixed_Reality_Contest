<?php

	require("connection.php");
	$id = intval($_POST["id"]);
	$is_occupied = intval($_POST["is_occupied"]);
	$status = intval($_POST["status"]);
	$is_waiting_water = intval($_POST["is_waiting_water"]);
	$is_waiting_waiter = intval($_POST["is_waiting_waiter"]);
	
	$query = "UPDATE `tables` ".
			"SET is_occupied = '{$is_occupied}', ".
			"status = '{$status}', ".
			"is_waiting_water = '{$is_waiting_water}', ".
			"is_waiting_waiter = '{$is_waiting_waiter}' ".
			"WHERE `id` = {$id}";

	echo $query;
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	echo "1: SQL query successsed";
?>
