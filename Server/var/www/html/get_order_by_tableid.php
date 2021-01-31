<?php
	/*
 	*  Input: id of target dish 
	*  Output: dishes name, positive vote, negative vote, calorie, comments on message board
	*/

	require("connection.php");
	
	$table_id = intval($_POST["table_id"]);
	
	// get name, calorire, pos vote, neg vote
	$query = "SELECT * FROM `orders` WHERE `table_id` = '{$table_id}'";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");
	$size = mysqli_num_rows($queryResult);

	if($size == 0)
	{
		echo "3: Not exists";
		exit();
	}
	
	
	while($row = mysqli_fetch_array($queryResult))
	{
		$result[] = array('size' => $size, 'id' => $row['id'], 'is_done' => $row['is_done'], 'is_finished'=> $row['is_finished'], 'waiter_id' => $row['waiter_id'], 'dish_id' => $row['dish_id'], 'table_id' => $row['table_id'], 'time' => $row['time']);
	}
	/*
	// get comments on message board
	$query =  "SELECT * FROM `orders` WHERE `id` > '{$order_id}' ";
	$queryResult = mysqli_query($con, $query) or die("2: Second SQL query failed");

	if(mysqli_num_rows($queryResult) == 0)
        {
                $result["Comments"][0] = "None";	
	}
	
	$comment_idx = 0;
	while($row = mysqli_fetch_assoc($queryResult)){
	 	$result["Comments"][$comment_idx] = $row["comment"];
		$comment_idx += 1;
	}
 */
	echo json_encode($result,true);	
?>
