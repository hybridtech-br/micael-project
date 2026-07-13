import http from 'node:http';
import fs from 'node:fs';
import path from 'node:path';
import { load, add } from './store.js';

const port = Number(process.env.PORT || 3000);
const root = path.resolve('public');
const collections = new Set(['residents','visitors','vehicles','panicEvents']);

function send(res,status,body,type='application/json; charset=utf-8'){
  res.writeHead(status,{'content-type':type,'access-control-allow-origin':'*','access-control-allow-headers':'content-type'});
  res.end(type.startsWith('application/json')?JSON.stringify(body):body);
}
async function readBody(req){let raw='';for await(const c of req) raw+=c;return raw?JSON.parse(raw):{};}
function serveFile(res,file){try{const data=fs.readFileSync(file);const ext=path.extname(file);const type=ext==='.html'?'text/html; charset=utf-8':ext==='.css'?'text/css; charset=utf-8':'text/javascript; charset=utf-8';send(res,200,data,type);}catch{send(res,404,{error:'not_found'});}}

const server=http.createServer(async(req,res)=>{
  if(req.method==='OPTIONS') return send(res,204,'','text/plain');
  const url=new URL(req.url,'http://localhost');
  if(url.pathname==='/api/health') return send(res,200,{status:'ok',version:'0.1.0'});
  if(url.pathname==='/api/dashboard'){
    const db=load();
    return send(res,200,{residents:db.residents.length,visitors:db.visitors.length,vehicles:db.vehicles.length,panicEvents:db.panicEvents.length});
  }
  const match=url.pathname.match(/^\/api\/(residents|visitors|vehicles|panicEvents)$/);
  if(match){
    const collection=match[1];
    if(req.method==='GET') return send(res,200,load()[collection]);
    if(req.method==='POST'){
      try{return send(res,201,add(collection,await readBody(req)));}
      catch{return send(res,400,{error:'invalid_json'});}
    }
  }
  if(url.pathname==='/'||url.pathname==='/index.html') return serveFile(res,path.join(root,'index.html'));
  if(url.pathname.startsWith('/')) return serveFile(res,path.join(root,url.pathname));
  send(res,404,{error:'not_found'});
});
server.listen(port,()=>console.log(`MICAEL MVP em http://localhost:${port}`));
export { server };
