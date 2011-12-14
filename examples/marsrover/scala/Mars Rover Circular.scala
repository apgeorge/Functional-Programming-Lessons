object Circular extends Application {
	
  object Dir extends Enumeration {
    val E, W, N, S = Value
  }
  
  import Dir._
  
  val leftRotations = List(E, N, W, S)
  val deltas = Map(E -> Loc(1, 0), N -> Loc(0, 1), W -> Loc(-1, 0), S -> Loc(0, -1))
  
  case class Loc(x: Int, y: Int) {
    def + (other: Loc) = Loc(x + other.x, y + other.y)
  }
  case class Pos(xy: Loc, d: Dir.Value) {
    def rotate(ds: List[Dir.Value]) = Stream.const(ds).flatMap(x=>x).dropWhile(d!=).tail.head
    def getNewPos(ch: Char) = ch match {
      case 'L' => Pos(xy, rotate(leftRotations))
      case 'R' => Pos(xy, rotate(leftRotations.reverse))
      case 'M' => Pos(xy + deltas(d), d)
    }
  }
  
	def run(pos: Pos, commands: List[Char]): Pos = commands match {
		case Nil => pos
		case head :: tail => run(pos.getNewPos head, tail)
	}
	
	val initPos = Pos(Loc(1, 2), N)
	val commands = "LMLMLMLMM".toList
	println(run(initPos, commands))
}
