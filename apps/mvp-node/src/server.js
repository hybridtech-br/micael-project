import http from 'node:http';
import fs from 'node:fs';
import path from 'node:path';
import { load, add } from './store.js';

const port = Number(process.env.PORT || 3000);
const root = path.resolve('public');

const send = (res, status, body, type = 'application/json; charset=utf-8') => {
  res.writeHead(status, { 'content-type': type, 'access-control-allow-origin': '*' });
  res.end(type.startsWith('application/json')