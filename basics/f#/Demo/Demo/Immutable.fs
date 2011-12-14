module immutable
open System.Drawing

type Rover = { pos : Point }

let r = { pos = Point(0,0) }

//let r = r.pos.Offset(1,2)








//let rnew =  { pos = r.pos.Offset(1,2) }






let rnew =  { pos = Point(r.pos.X+1,r.pos.Y + 2) }
























/// A Point
type PointNew(x:int, y:int) = 
    member p.X = x
    member p.Y = y
    member p.Offset(dx,dy) = PointNew(x+dx, y+dy)

type RoverNew = { pos : PointNew }
    
let frover = { pos = PointNew(0,0) }

let froverNew = { pos = frover.pos.Offset(1,2) }






