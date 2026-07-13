import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';

const file = process.env.MICAEL_DATA_FILE || path.resolve('data/micael.json');
const empty = { residents: [], visitors: [], vehicles: [], panicEvents: [] };

export function load() {
  try { return JSON.parse(fs.readFileSync(file, 'utf8')); }
  catch { return structuredClone(empty); }
}

export function save(db) {
  fs.mkdirSync(path.dirname(file), { recursive: true });
  fs.writeFileSync(file, JSON.stringify(db, null, 2));
}

export function add(collection, payload) {
  const db = load();
  const item = { id: crypto.randomUUID(), createdAt: new Date().toISOString(), ...payload };
  db[collection].push(item);
  save(db);
  return item;
}
