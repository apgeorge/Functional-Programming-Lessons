module rover2
// 0 0 N
// RML
// 1 0 N

type Probability = 
    | Value of float



type Direction = 
 | N
 | E
 | S
 | W
 
 
let initialPos = ((0,0),N)

type Move = 
 | M
 
type Rotate = 
 | R
 | L

type Command = 
 | Move
 | Rotate of Rotate


let dirList = [N;E;S;W]
let dxdyList = [(0,1);(1,0);(0,-1);(-1,0)]

let getDirIncrement rotateCommand = 
 match rotateCommand with
    | R -> 1
    | L -> -1
 
let getDirAt(newDirindex) = 
 let index = if newDirindex = -1 then 3 else newDirindex
 dirList.[index]

let rotate command ((x,y),D) =
 let currDirindex = dirList |> List.findIndex (fun dir -> dir = D)  
 let newDirindex = (currDirindex + (getDirIncrement command)) % 4
 ((x,y),getDirAt(newDirindex))
    
    
let move ((x,y),D) = 
 let currDirindex = dirList |> List.findIndex (fun dir -> dir = D)  
 let (dx,dy) = dxdyList.[currDirindex]
 ((x+dx,y+dy),D)
 

let commands:Command list = [Rotate(R);Move;Rotate(L)]
