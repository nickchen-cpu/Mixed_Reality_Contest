<?php
	/*
 	*  Input: id of target dish 
	*  Output: Nothing
	*/

	require("connection.php");
	
	$dish_id = intval($_POST["dish_id"]);
	if ($dish_id <= 0)
	{
		die("4: Dish ID Error");
    }
    
    $comment = strval($_POST["comment"]);
    if (empty($comment))
    {
        die("5: Empty Comment Error");
    }

	// get name, calorire, pos vote, neg vote
    $query = "INSERT INTO `dishes_comments` (`dish_id`, `comment`) VALUE ($dish_id, \"$comment\")";
	
	$queryResult = mysqli_query($con, $query) or die("2: SQL query failed");
    
	echo true;
?>
