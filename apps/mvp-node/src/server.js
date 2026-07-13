import http from 'node:http';
import fs from 'node:fs';
import path from 'node:path';
import { load, add } from './store.js';

const port = Number(process.env.PORT || 3000);
const publicDir = path.resolve('public');

function json(res, status, body) {
  res.writeHead(status, { 'content-type': 'application/json; charset=utf-8', 'access-control-allow-origin': '*' });
  res.end(JSON.stringify(body));
}

async function body(req) {
  let