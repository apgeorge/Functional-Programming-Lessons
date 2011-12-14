object MarsRover extends Application {
	val bounds = Map("x" -> 5, "y" -> 5)
	val initPos = Pos(1, 2, 'N')
	val commands = "LMLMLMLMM".toList

	case class Pos(x: Int, y: Int, direction: Char) {
		def move(command: Char) = (direction, command) match {
			case ('E', 'L') => Pos(x, y, 'N')
			case ('N', 'L') => Pos(x, y, 'W')
			case ('W', 'L') => Pos(x, y, 'S')
			case ('S', 'L') => Pos(x, y, 'E')
			
			case ('E', 'R') => Pos(x, y, 'S')
			case ('S', 'R') => Pos(x, y, 'W')
			case ('W', 'R') => Pos(x, y, 'N')
			case ('N', 'R') => Pos(x, y, 'E')
			
			case ('E', 'M') => Pos(x+1, y, 'E')
			case ('N', 'M') => Pos(x, y+1, 'N')
			case ('W', 'M') => Pos(x-1, y, 'W')
			case ('S', 'M') => Pos(x, y-1, 'S')
		}
	}
	
	def run(pos: Pos, commands: List[Char]): Pos = commands match {
		case Nil => pos
		case command :: tail => run(pos move command, tail)
	}
	
	val finalPos = run(initPos, commands)
	println(finalPos)
}
