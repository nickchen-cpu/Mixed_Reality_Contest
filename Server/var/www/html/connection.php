<?php
    /*
 	*  Setup Connection
    */
    
    $con = mysqli_connect('localhost', 'UnityGroup', 'tqQGVyCY5vvVexE=u$RgH?u2v?U!2adKH2XcU4@*.xuHn-.mUygTdp#s#BCUmq5H', 'unityaccess');
	//check that connection happened
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed ";
		exit();
	}
?>
