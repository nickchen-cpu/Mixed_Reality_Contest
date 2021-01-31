<?php
	/*
 	*  Input: id of target dish 
	*  Output: dishes name, positive vote, negative vote, calorie, comments on message board
	*/

	require("connection.php");
	
	// get name, calorire, pos vote, neg vote
	$query = "SELECT * FROM `tables`";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	if(mysqli_num_rows($queryResult) == 0)
	{
		echo "3: Not exists";
		exit();
	}
	
	
	//$row = mysqli_fetch_assoc($queryResult);
	while($row = mysqli_fetch_array($queryResult))
	{
		$result[] = array('id' => $row['id'], 
						'is_occupied' => $row['is_occupied'], 
						'status' => $row['status'], 
						'is_waiting_water' => $row['is_waiting_water'], 
						'is_waiting_waiter' => $row['is_waiting_waiter']
						);

	}
	echo json_encode($result, true);	
?>
