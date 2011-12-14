module rover31

open System
let sin x = Math.Sin (x*Math.PI/180.0)
let cos x = Math.Cos (x*Math.PI/180.0)

let l = [0..360/4..360]
let deltas = [ for  theta in l do yield sin (float(theta)),cos (float(theta))]

type DirectionValue = N|S|E|W

type Direction = { direction: DirectionValue;
                 left : DirectionValue;
                 right : DirectionValue;
                 delta : int*int }


let directionMap = Map.ofList [ N,{direction=N;left=W;right=E;delta= 0,1};
                                 E,{direction=E;left=N;right=S;delta= 1,0};   
                                 S,{direction=S;left=E;right=W;delta= 0,-1};   
                                 W,{direction=W;left=S;right=N;delta= -1,0};   
                                 ]
                                 
let clockwise = [N;E;S;W]

//let makeDirMap l = 
//    let rec circularDirSeq l = seq {
//        match l with
//            | first::second::third::fourth::tl -> yield second,{direction=second;right=third;left=first;delta= 0,0}
//                                                  yield! circularDirSeq (second::third::fourth::l)
//            | first::second::third::[] -> yield second,{direction=second;right=third;left=first;delta= 0,0}
//                                          yield! circularDirSeq (second::third::l)
//            | _ -> ()
//            | p (x::p) -> 
//            }
//    (circularDirSeq l) |> Seq.take l.Length  |> Map.ofSeq
    



let move (x,y,d) = 
    let (dx,dy) = directionMap.[d].delta
    (x+dx,y+dy,d)
    
let turnRight (x,y,d) =
    let nextDir = directionMap.[d].right
    (x,y,nextDir)
    
let turnLeft (x,y,d) =
    let nextDir = directionMap.[d].left
    (x,y,nextDir)
    

let commandMap = Map.ofList ['M',move;'R',turnRight;'L',turnLeft]

let commands = "LMRRMMLLRLM" |> List.ofSeq |> List.map (fun x -> commandMap.[x])

let f = commands |> List.reduce (>>)

let initPos = (1,1,N)

let finalPos = f initPos

