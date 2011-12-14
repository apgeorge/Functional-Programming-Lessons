object MarsRover extends Application {
	
  object Direction extends Enumeration {
    val E, N, W, S = Value
    val directions = elements.toList ++ List(apply(0))
    val leftTruns = Map.empty ++ (directions.init zip directions.tail)
    val rightTurns = Map.empty ++ (directions.tail zip directions.init)
    val deltas = Map(E -> Location(1, 0), N -> Location(0, 1), W -> Location(-1, 0), S -> Location(0, -1))
  }
  
  case class Location(x: Int, y: Int) {
    def + (other: Location) = Location(x + other.x, y + other.y)
  }
  
  case class Position(xy: Location, direction: Direction.Value) {
    def getNewPos(ch: Char) = ch match {
      case 'L' => Position(xy, Direction leftTruns direction)
      case 'R' => Position(xy, Direction rightTurns direction)
      case 'M' => Position(xy + Direction.deltas(direction), direction)
    }
    
    def run(commands: List[Char]): Position = commands match {
    	case Nil => this
    	case head :: tail => getNewPos(head) run tail
    }
  }
	
	val initPos = Position(Location(3, 3), Direction.E)
	val commands = "MMRMMRMRRM".toList
	println(initPos run commands)
}
