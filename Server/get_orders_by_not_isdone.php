<?php

	require("connection.php");
	
	$query = "SELECT * FROM `orders` WHERE `is_done` = 0";
	
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
						'is_finished' => $row['is_finished'], 
						'waiter_id' => $row['waiter_id'], 
						'dish_id' => $row['dish_id'], 
						'table_id' => $row['table_id'], 
						);

	}
	
	
	echo json_encode($result, true);	
?>
