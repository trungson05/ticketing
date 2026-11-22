
CREATE TABLE IF NOT EXISTS ticket_inventory (
    id INTEGER PRIMARY KEY,
    total INTEGER NOT NULL,
    sold INTEGER NOT NULL DEFAULT 0
);

INSERT INTO ticket_inventory (id, total, sold)
VALUES (1, 100, 0)
ON CONFLICT (id)
DO UPDATE SET
    total = 100,
    sold = 0;
