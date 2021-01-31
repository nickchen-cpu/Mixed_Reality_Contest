<?php
	/*
 	*  Input: id of target dish 
	*  Output: Nothing
	*/

	require("connection.php");

	$dish_id = intval($_POST["dish_id"]);
	if ($dish_id <= 0)
	{
		die("Dish ID Error");
	}

	// get name, calorire, pos vote, neg vote
	$query = "SELECT neg_vote FROM `dishes` WHERE `id` = '{$dish_id}' ";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

	if(mysqli_num_rows($queryResult) == 0)
	{
		echo "3: Not exists";
		exit();
	}

	$row = mysqli_fetch_assoc($queryResult);
	
	$result = intval($row['neg_vote']);

    // Update pos_vote by add 1
    $query = "UPDATE `dishes` SET `neg_vote` = ($result + 1) WHERE `id` = '{$dish_id}'";
    
    $queryResult = mysqli_query($con, $query) or die("3: Second SQL query failed");
    
	echo true;	
?>
