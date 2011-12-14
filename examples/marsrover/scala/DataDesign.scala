object DataDesign extends Application {
	 
  class Direction(val x: Int, val y: Int, l: =>Direction, r: =>Direction) {
    def left = l
    def right = r
  }
  
  def E = new Direction(1, 0, N, S)
  def W = new Direction(-1, 0, S, N)
  def N: Direction = new Direction(0, 1, W, E)
  def S: Direction = new Direction(0, -1, E, W)
  
  case class Position(x: Int, y: Int, direction: Direction) {
    def !(command: Char) = command match {
      case 'L' => Position(x, y, direction.left)
      case 'R' => Position(x, y, direction.right)
      case 'M' => Position(x + direction.x, y + direction.y, direction)
    }
  }
	
  val initPos = Position(3, 3, E)
  val result = "MMRMMRMRRM".foldLeft(initPos)(_ ! _)
  println(result)
}
