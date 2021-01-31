<?php
	/*
 	*  Input: id of target dish 
	*  Output: dishes name, positive vote, negative vote, calorie, comments on message board
	*/

	require("connection.php");
	
	$dish_id = intval($_POST["dish_id"]);
	if ($dish_id <= 0)
	{
		die("Dish ID Error");
	}
	
	// get name, calorire, pos vote, neg vote
	$query = "SELECT * FROM `dishes` WHERE `id` = '{$dish_id}' ";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	if(mysqli_num_rows($queryResult) == 0)
	{
		echo "3: Not exists";
		exit();
	}
	
	
	$row = mysqli_fetch_assoc($queryResult);
	
	$result = array('name' => $row['name'], 'calorie' => $row['calorie'], 'pos_vote' => $row['pos_vote'], 'neg_vote' => $row['neg_vote']);

	// get comments on message board
	$query =  "SELECT `comment` FROM `dishes_comments` WHERE `dish_id` = '{$dish_id}' ";
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

	echo json_encode($result);	
?>
