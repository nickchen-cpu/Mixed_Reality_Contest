<?php
	/*
 	*  Input: id of target waiter 
	*  Output: The name of waiter
	*/
	require("connection.php");
	
	$waiter_id = intval($_POST["waiter_id"]);
	if ($waiter_id <= 0)
	{
		die("4: Waiter ID Error");
    }

	// get name
    $query = "SELECT * FROM `waiters` WHERE `id` = '{$waiter_id}'";

    $queryResult = mysqli_query($con, $query) or die("2: SQL query failed");

    $row = mysqli_fetch_assoc($queryResult);
    
    $r_object = array('success_flag' => true, 'name' => $row["name"]);

    echo json_encode($r_object);
?>
