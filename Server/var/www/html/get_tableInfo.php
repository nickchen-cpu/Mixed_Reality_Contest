<?php
	/*
 	*  Input: 
	*  Output: 
	*/

	require("connection.php");
	$table_id = intval($_POST["table_id"]);
	if ($table_id <= 0)
	{
		die("Table ID Error");
	}
	
	$query = "SELECT * FROM `tables` WHERE `id` = '{$table_id}' ";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");
	
		if(mysqli_num_rows($queryResult) == 0)
	{
		echo "3: Not exists";
		exit();
	}
	
	$row = mysqli_fetch_assoc($queryResult);

	
	$result = array('status' => $row['status'], 'status_start_time' => $row['status_start_time'], 'is_waiting_water' => $row['is_waiting_water'], 'is_waiting_waiter' => $row['is_waiting_waiter']);
	
	
	echo json_encode($result);	
	
	
	
	
?>