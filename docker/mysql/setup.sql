INSERT INTO users(EMAIL, PASSWORD, ROLE)
VALUES ('admin@admin.com',
        'nie_zalogujesz_sie_bo_hasze_sa',
        'admin');

INSERT INTO events(name, price, place, date, short_info, description, image_url, number_of_available_tickets,
                   created_by)
SELECT 'Metallica',
       420,
       'Wrocław',
       '2019-01-19 03:14:07',
       'Koncert legendy metalu, na którym musisz być',
       'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi fringilla urna lacus, vestibulum mattis odio semper ut. Quisque fermentum gravida lorem sodales lacinia. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus semper interdum lectus, eget fermentum risus pretium at. Praesent id orci scelerisque, venenatis ante in, volutpat diam. Aliquam molestie dignissim enim ut venenatis. Pellentesque et libero in arcu faucibus faucibus eget vel ante. Curabitur scelerisque lectus congue urna placerat, eu venenatis purus luctus. Duis consectetur nunc a tellus bibendum iaculis. Suspendisse consectetur tincidunt elit, et rhoncus elit luctus vel. Proin ullamcorper augue non nunc scelerisque lacinia. Mauris suscipit lectus lacus, sed varius dui tempor at. Sed eget rutrum ligula, ac ultricies massa. Nulla egestas nisi a ornare tincidunt.',
       'https://amp.businessinsider.com/images/5bad1be2e55aa8fa0e8b4567-750-563.jpg',
       400,
       id
FROM users
WHERE email = 'admin@admin.com';

INSERT INTO events(name, price, place, date, short_info, description, image_url, number_of_available_tickets,
                   created_by)
SELECT 'Led Zeppelin',
       500,
       'Warszawa',
       '2018-10-11 12:00:00',
       'Koncert legendy rocka, wystąpi też razem z nimi lorem',
       'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi fringilla urna lacus, vestibulum mattis odio semper ut. Quisque fermentum gravida lorem sodales lacinia. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus semper interdum lectus, eget fermentum risus pretium at. Praesent id orci scelerisque, venenatis ante in, volutpat diam. Aliquam molestie dignissim enim ut venenatis. Pellentesque et libero in arcu faucibus faucibus eget vel ante. Curabitur scelerisque lectus congue urna placerat, eu venenatis purus luctus. Duis consectetur nunc a tellus bibendum iaculis. Suspendisse consectetur tincidunt elit, et rhoncus elit luctus vel. Proin ullamcorper augue non nunc scelerisque lacinia. Mauris suscipit lectus lacus, sed varius dui tempor at. Sed eget rutrum ligula, ac ultricies massa. Nulla egestas nisi a ornare tincidunt.',
       'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstR8KPbn-GsQMNSlujHU-GR_uXAoURfPYPCJWDRXQoKmBMwSL',
       1000,
       id
FROM users
WHERE email = 'admin@admin.com';

INSERT INTO events(name, price, place, date, short_info, description, image_url, number_of_available_tickets,
                   created_by)
SELECT 'Rammstein',
       320,
       'Kalisz',
       '2019-02-11 12:00:00',
       'Koncert niemieckiego zespołu',
       'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi fringilla urna lacus, vestibulum mattis odio semper ut. Quisque fermentum gravida lorem sodales lacinia. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus semper interdum lectus, eget fermentum risus pretium at. Praesent id orci scelerisque, venenatis ante in, volutpat diam. Aliquam molestie dignissim enim ut venenatis. Pellentesque et libero in arcu faucibus faucibus eget vel ante. Curabitur scelerisque lectus congue urna placerat, eu venenatis purus luctus. Duis consectetur nunc a tellus bibendum iaculis. Suspendisse consectetur tincidunt elit, et rhoncus elit luctus vel. Proin ullamcorper augue non nunc scelerisque lacinia. Mauris suscipit lectus lacus, sed varius dui tempor at. Sed eget rutrum ligula, ac ultricies massa. Nulla egestas nisi a ornare tincidunt.',
       'https://ichef.bbci.co.uk/images/ic/960x540/p01bqw3r.jpg',
       1000,
       id
FROM users
WHERE email = 'admin@admin.com';

INSERT INTO events(name, price, place, date, short_info, description, image_url, number_of_available_tickets,
                   created_by)
SELECT 'The Beatles',
       1200,
       'Leszno',
       '2019-02-11 12:00:00',
       'Koncert niemieckiego zespołu',
       'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi fringilla urna lacus, vestibulum mattis odio semper ut. Quisque fermentum gravida lorem sodales lacinia. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus semper interdum lectus, eget fermentum risus pretium at. Praesent id orci scelerisque, venenatis ante in, volutpat diam. Aliquam molestie dignissim enim ut venenatis. Pellentesque et libero in arcu faucibus faucibus eget vel ante. Curabitur scelerisque lectus congue urna placerat, eu venenatis purus luctus. Duis consectetur nunc a tellus bibendum iaculis. Suspendisse consectetur tincidunt elit, et rhoncus elit luctus vel. Proin ullamcorper augue non nunc scelerisque lacinia. Mauris suscipit lectus lacus, sed varius dui tempor at. Sed eget rutrum ligula, ac ultricies massa. Nulla egestas nisi a ornare tincidunt.',
       'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/The_Beatles_and_Lill-Babs_1963.jpg/220px-The_Beatles_and_Lill-Babs_1963.jpg',
       100,
       id
FROM users
WHERE email = 'admin@admin.com';
