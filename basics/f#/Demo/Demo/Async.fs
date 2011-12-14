module asyncs
open Microsoft.FSharp.Control
open System.Net
open System.IO

//TODO: Rewrite this as api has changed

//let download (url:string) =
// async {
//    let req = HttpWebRequest.Create(url)
//    let! resp = req.AsyncGetResponse()
//    let stream = resp.GetResponseStream()
//    use streamReader = new StreamReader(stream)
//    let! text = streamReader.AsyncReadToEnd()
//    printf "%s" text
//    return text
// }
// 
//let s = Async.Run(download("http://www.google.com"))
//printf "Returned html %s" s
//
//let tasks = [ download("http://www.tomasp.net");download("http://www.manning.com");download("http://microsoft.com") ]
//let all = Async.Parallel(tasks)
//let texts = Async.SpawnFuture(all)
//printf "Running threads..."


