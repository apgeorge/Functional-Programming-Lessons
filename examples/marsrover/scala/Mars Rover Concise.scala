object Concise extends Application {
	 
  case class Dir(x: Int, y: Int)
  val (east, west, north, south) = (Dir(1,0), Dir(-1,0), Dir(0,1), Dir(0,-1))
  val directions = List(north, west, south, east, north)
  
  val leftTruns = Map.empty ++ (directions.init zip directions.tail)
  val rightTurns = Map.empty ++ (directions.tail zip directions.init)
  
  case class Position(x: Int, y: Int, direction: Dir) {
    def getNewPos(command: Char) = command match {
      case 'L' => Position(x, y, leftTruns(direction))
      case 'R' => Position(x, y, rightTurns(direction))
      case 'M' => Position(x + direction.x, y + direction.y, direction)
    }
  }
	
  val initPos = Position(3, 3, east)
  val result = "MMRMMRMRRM".foldLeft(initPos)(_ getNewPos _)
  println(result)
}
