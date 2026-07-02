CREATE TYPE role_area AS ENUM('OPERATIVE','ADMIN');
CREATE TYPE status_enterprises AS ENUM('ACTIVE','INACTIVE');
CREATE TYPE profile_status AS ENUM('ACTIVE','INACTIVE');
CREATE TYPE machine_status AS ENUM('ACTIVE','INACTIVE', 'MAINTENANCE');
CREATE TYPE unit_measure_type AS ENUM('KG','CM','MT','GR','ML','UN');
CREATE TYPE product_status AS ENUM('ACTIVE','DISCONTINUED','INACTIVE');
CREATE TYPE process_status AS ENUM('ACTIVE','INACTIVE');
CREATE TYPE warehouse_status AS ENUM('ACTIVE','INACTIVE');
CREATE TYPE provider_type AS enum('INTERNAL','PROVIDER');
CREATE TYPE product_type AS ENUM('PP','PT','MP','INPUT','TOOL','COMBO');
CREATE TYPE odp_type  AS ENUM('BASIC','COMBO','PAINTING','DPNC BASIC','DPNC PAINTING');
CREATE TYPE odp_status AS ENUM('IN_PROCESS','COMPLETED','CANCELLED','FREEDOM','PENDING');
CREATE TYPE dpnc_status AS ENUM('PENDING','COMPLETED');
CREATE TYPE dpnc_solution AS ENUM('REJECTED','REPROCESSED','RECLASIFICATED','REPROCESSES_PROVIDER','RECYCLED','HAND_TO_HAND');
CREATE TYPE schedule_status AS ENUM('PENDING','IN_PROGRESS','COMPLETED','CANCELLED');
CREATE TYPE orders_status AS ENUM('PENDING','IN_PROGRESS','COMPLETED','CANCELLED');
CREATE TYPE provider_calification  AS ENUM('EXCELLENT','GOOD','AVERAGE','BAD','VERY_BAD');
CREATE TYPE payment_method AS ENUM('CASH','CREDIT_CARD','DEBIT_CARD','TRANSFER','OTHER');
CREATE TYPE payment_status AS ENUM('PENDING','PAID','REFUNDED');

/*
monetary values struct 999.999.999,99 (11,2)
measure values struct 999.999.999,9999 (13,4)
*/
/*
Movement database will be create with NoSQL database (MongoDB | Firebase | DynamoDB)

struct (
_id: string,
reference:string,
type:IN|OUT,
quantity:number,
previous_quantity:number,
new_quantity:number,
user_id:number,
from_warehouse:number,
to_warehouse:number,
warehouse_type:AVAILABLE|RESERVED,
details:string,
created_at:timestamp,
origin:OS|OC|ODP|DPNC|
)

*/

CREATE TABLE roles(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL,
    description TEXT,
    type role_area NOT NULL
);

CREATE TABLE users(
    id BIGSERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(256) NOT NULL,
    name VARCHAR(100) NOT NULL,
    middlename VARCHAR(100),
    lastname VARCHAR(150) NOT NULL,
    phone VARCHAR(20) UNIQUE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    photo_url TEXT
);

CREATE TABLE enterprises(
    id  BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    nit VARCHAR(256) NOT NULL UNIQUE,
    address VARCHAR(512) NOT NULL,
    phone VARCHAR(21) NOT NULL UNIQUE,
    email VARCHAR(255) NOT NULL UNIQUE,
    status status_enterprises NOT NULL DEFAULT 'ACTIVE'
);
CREATE TABLE turns (
    id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    from_time TIME NOT NULL,
    to_time TIME NOT NULL
);
CREATE TABLE areas (
    id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL
);

CREATE TABLE profiles(
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT NOT NULL,
    enterprice_id BIGINT NOT NULL,
    status profile_status NOT NULL DEFAULT 'ACTIVE',
    salary_hour DECIMAL(11,2) NOT NULL DEFAULT 0.00,
    leader_id BIGINT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    turn_id INT NOT NULL,
    area_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (enterprice_id) REFERENCES enterprises(id),
    FOREIGN KEY (turn_id) REFERENCES turns(id),
    FOREIGN KEY (area_id) REFERENCES areas(id)
);

CREATE TABLE permissions(
    id BIGSERIAL PRIMARY KEY,
    role_id BIGINT NOT NULL,
    profile_id BIGINT NOT NULL,
    /*Begin of permissions list*/
    create_user BOOLEAN DEFAULT FALSE,
    read_user BOOLEAN DEFAULT FALSE,
    update_user BOOLEAN DEFAULT FALSE,
    delete_user BOOLEAN DEFAULT FALSE,
    create_roles BOOLEAN DEFAULT FALSE,
    read_roles BOOLEAN DEFAULT FALSE,
    update_roles BOOLEAN DEFAULT FALSE,
    delete_roles BOOLEAN DEFAULT FALSE,
    create_enterprises BOOLEAN DEFAULT FALSE,
    read_enterprises BOOLEAN DEFAULT FALSE,
    update_enterprises BOOLEAN DEFAULT FALSE,
    delete_enterprises BOOLEAN DEFAULT FALSE,
    create_turn BOOLEAN DEFAULT FALSE,
    read_turn BOOLEAN DEFAULT FALSE,
    update_turn BOOLEAN DEFAULT FALSE,
    delete_turn BOOLEAN DEFAULT FALSE,
    create_areas BOOLEAN DEFAULT FALSE,
    read_areas BOOLEAN DEFAULT FALSE,
    update_areas BOOLEAN DEFAULT FALSE,
    delete_areas BOOLEAN DEFAULT FALSE,
    create_machines BOOLEAN DEFAULT FALSE,
    read_machines BOOLEAN DEFAULT FALSE,
    update_machines BOOLEAN DEFAULT FALSE,
    delete_machines BOOLEAN DEFAULT FALSE,
    create_products BOOLEAN DEFAULT FALSE,
    read_products BOOLEAN DEFAULT FALSE,
    update_products BOOLEAN DEFAULT FALSE,
    delete_products BOOLEAN DEFAULT FALSE,
    create_processes BOOLEAN DEFAULT FALSE,
    read_processes BOOLEAN DEFAULT FALSE,
    update_processes BOOLEAN DEFAULT FALSE,
    delete_processes BOOLEAN DEFAULT FALSE,
    create_bom BOOLEAN DEFAULT FALSE,
    read_bom BOOLEAN DEFAULT FALSE,
    update_bom BOOLEAN DEFAULT FALSE,
    delete_bom BOOLEAN DEFAULT FALSE,
    create_providers BOOLEAN DEFAULT FALSE,
    read_providers BOOLEAN DEFAULT FALSE,
    update_providers BOOLEAN DEFAULT FALSE,
    delete_providers BOOLEAN DEFAULT FALSE,
    create_contacts BOOLEAN DEFAULT FALSE,
    read_contacts BOOLEAN DEFAULT FALSE,
    update_contacts BOOLEAN DEFAULT FALSE,
    delete_contacts BOOLEAN DEFAULT FALSE,
    create_services BOOLEAN DEFAULT FALSE,
    read_services BOOLEAN DEFAULT FALSE,
    update_services BOOLEAN DEFAULT FALSE,
    delete_services BOOLEAN DEFAULT FALSE,
    create_odp BOOLEAN DEFAULT FALSE,
    read_odp BOOLEAN DEFAULT FALSE,
    update_odp BOOLEAN DEFAULT FALSE,
    delete_odp BOOLEAN DEFAULT FALSE,
    create_report_odp BOOLEAN DEFAULT FALSE,
    read_report_odp BOOLEAN DEFAULT FALSE,
    update_report_odp BOOLEAN DEFAULT FALSE,
    delete_report_odp BOOLEAN DEFAULT FALSE,
    create_dpnc BOOLEAN DEFAULT FALSE,
    read_dpnc BOOLEAN DEFAULT FALSE,
    update_dpnc BOOLEAN DEFAULT FALSE,
    delete_dpnc BOOLEAN DEFAULT FALSE,
    create_solution_dpnc BOOLEAN DEFAULT FALSE,
    read_solution_dpnc BOOLEAN DEFAULT FALSE,
    update_solution_dpnc BOOLEAN DEFAULT FALSE,
    delete_solution_dpnc BOOLEAN DEFAULT FALSE,
    create_schedule BOOLEAN DEFAULT FALSE,
    read_schedule BOOLEAN DEFAULT FALSE,
    update_schedule BOOLEAN DEFAULT FALSE,
    delete_schedule BOOLEAN DEFAULT FALSE,
    create_oc BOOLEAN DEFAULT FALSE,
    read_oc BOOLEAN DEFAULT FALSE,
    update_oc BOOLEAN DEFAULT FALSE,
    delete_oc BOOLEAN DEFAULT FALSE,
    create_os BOOLEAN DEFAULT FALSE,
    read_os BOOLEAN DEFAULT FALSE,
    update_os BOOLEAN DEFAULT FALSE,
    delete_os BOOLEAN DEFAULT FALSE,
    create_payments BOOLEAN DEFAULT FALSE,
    read_payments BOOLEAN DEFAULT FALSE,
    update_payments BOOLEAN DEFAULT FALSE,
    delete_payments BOOLEAN DEFAULT FALSE,
    read_reports BOOLEAN DEFAULT FALSE,
    generated_reports BOOLEAN DEFAULT FALSE,
    read_reception BOOLEAN DEFAULT FALSE,
    update_reception BOOLEAN DEFAULT FALSE,
    delete_reception BOOLEAN DEFAULT FALSE,
    create_reception BOOLEAN DEFAULT FALSE,
    /*end of permissions list*/
    FOREIGN KEY (role_id) REFERENCES roles(id),
    FOREIGN KEY (profile_id) REFERENCES profiles(id)
);

CREATE TABLE machines(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    description  TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP,
    position   DECIMAL[3],
    brand VARCHAR(256),
    last_maintenance TIMESTAMP,
    status machine_status DEFAULT 'INACTIVE',
    model VARCHAR(300)
);

CREATE TABLE products (
    id BIGSERIAL PRIMARY KEY,
    reference VARCHAR(256) UNIQUE NOT NULL,
    description TEXT,
    cost DECIMAL(11,2) DEFAULT 0.0,
    sale_price DECIMAL(11,2) DEFAULT 0.0,
    x DECIMAL(6,2) DEFAULT 0.0,
    y DECIMAL(6,2) DEFAULT 0.0,
    z DECIMAL(6,2) DEFAULT 0.0,
    minimal_point DECIMAL(13,4) DEFAULT 0.0,
    maximal_point DECIMAL(13,4) DEFAULT 0.0,
    gtin VARCHAR(256),
    image VARCHAR(300),
    weight DECIMAL(13,4),
    unit_measure unit_measure_type DEFAULT 'UN',
    status product_status DEFAULT 'ACTIVE',
    product_type product_type DEFAULT NULL
);

CREATE TABLE processes(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(300),
    description TEXT,
    status process_status DEFAULT 'ACTIVE',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP
);

CREATE TABLE bom(
    id_reference BIGINT NOT NULL,
    id_component BIGINT NOT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    recipe SMALLINT DEFAULT 1,
    UNIQUE(id_reference,id_component,recipe),
    FOREIGN KEY (id_reference) REFERENCES products(id),
    FOREIGN KEY (id_component) REFERENCES products(id)
);

CREATE TABLE process_bom(
    id BIGSERIAL PRIMARY KEY ,
    id_reference  BIGINT NOT NULL,
    recipe_number SMALLINT NOT NULL,
    process_id BIGINT NOT NULL,
    sam DECIMAL(6,2),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_reference) REFERENCES products(id),
    FOREIGN KEY (process_id) REFERENCES processes(id)
);

CREATE TABLE providers(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    nit VARCHAR(256),
    address VARCHAR(512) NOT NULL,
    phone VARCHAR(21) NOT NULL UNIQUE,
    email VARCHAR(255) NOT NULL UNIQUE,
    type provider_type DEFAULT 'PROVIDER',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE contacts(
    id BIGSERIAL PRIMARY KEY,
    firstname VARCHAR(50) NOT NULL,
    middlename VARCHAR(50),
    lastname VARCHAR(150) NOT NULL,
    phone VARCHAR(21) UNIQUE NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    id_provider  BIGINT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_provider) REFERENCES providers(id)
);
CREATE TABLE warehouse(
    id BIGSERIAL PRIMARY KEY,
    id_provider  BIGINT NOT NULL,
    id_product BIGINT NOT NULL,
    quantity_available DECIMAL(13,4) DEFAULT 0.0,
    quantity_reservate DECIMAL(13,4) DEFAULT 0.0,
    status warehouse_status DEFAULT 'ACTIVE',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_provider) REFERENCES providers(id)
);

CREATE TABLE services(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(150) UNIQUE,
    description TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE provider_service(
    id BIGSERIAL PRIMARY KEY,
    product_id BIGINT,
    service_id BIGINT,
    provider_id BIGINT NOT NULL,
    value DECIMAL(11,2) DEFAULT 0.0,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (service_id) REFERENCES services(id),
    FOREIGN KEY (provider_id) REFERENCES providers(id)
);

CREATE TABLE odp (
    id BIGSERIAL PRIMARY KEY,
    type odp_type DEFAULT 'BASIC',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    finished_at TIMESTAMP DEFAULT NULL,
    odp_items JSONB[],
    status ODP_STATUS DEFAULT 'PENDING'
);

CREATE TABLE odp_process_bom (
    id BIGSERIAL PRIMARY KEY,
    id_process_bom BIGINT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    FOREIGN KEY (id_process_bom) REFERENCES process_bom(id)
);

CREATE TABLE odp_process_bom_register (
    id BIGSERIAL PRIMARY KEY,
    id_odp_process_bom BIGINT NOT NULL,
    id_machine BIGINT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    user_id BIGINT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (id_odp_process_bom) REFERENCES odp_process_bom(id),
    FOREIGN KEY (id_machine) REFERENCES machines(id)
);

CREATE TABLE dpnc (
    id BIGINT PRIMARY KEY,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    finished_at TIMESTAMP DEFAULT NULL,
    status dpnc_status DEFAULT 'PENDING',
    odp BIGINT,
    FOREIGN KEY (odp) REFERENCES odp(id)
);

CREATE TABLE dpnc_items (
    id BIGSERIAL PRIMARY KEY,
    id_dpnc BIGINT NOT NULL,
    id_product BIGINT NOT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    is_completed BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (id_dpnc) REFERENCES dpnc(id),
    FOREIGN KEY (id_product) REFERENCES products(id)
);

CREATE TABLE dpnc_solutions (
    id BIGSERIAL PRIMARY KEY,
    id_dpnc_item BIGINT NOT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    solution dpnc_solution NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    solved_by BIGINT NOT NULL,
    odp_id BIGINT DEFAULT NULL,
    hand_to_hand_file VARCHAR(256) DEFAULT NULL,
    FOREIGN KEY (solved_by) REFERENCES users(id),
    FOREIGN KEY (id_dpnc_item) REFERENCES dpnc_items(id)
);

CREATE TABLE monthly_schedule (
    id BIGSERIAL PRIMARY KEY,
    reference_id BIGINT NOT NULL,
    schedule_date DATE NOT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    status schedule_status DEFAULT 'PENDING',
    updated_at TIMESTAMP DEFAULT NULL,
    FOREIGN KEY (reference_id) REFERENCES products(id)
);

CREATE TABLE weekly_schedule (
    id BIGSERIAL PRIMARY KEY,
    monthly_schedule_id BIGINT NOT NULL,
    schedule_date DATE NOT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    status schedule_status DEFAULT 'PENDING',
    updated_at TIMESTAMP DEFAULT NULL,
    FOREIGN KEY (monthly_schedule_id) REFERENCES monthly_schedule(id)  
);

CREATE TABLE layout (
    id BIGSERIAL PRIMARY KEY,
    machine_id BIGINT NOT NULL,
    position_x INT DEFAULT 0,
    position_y INT DEFAULT 0,
    position_z INT DEFAULT 0,
    visible BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    FOREIGN KEY (machine_id) REFERENCES machines(id)
);


CREATE TABLE buy_orders(
    id BIGSERIAL PRIMARY KEY,
    id_provider BIGINT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    status orders_status DEFAULT 'PENDING',
    FOREIGN KEY (id_provider) REFERENCES providers(id)
);

CREATE TABLE buy_order_items(
    id BIGSERIAL PRIMARY KEY,
    id_buy_order BIGINT NOT NULL,
    id_product BIGINT NOT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    quantity_received DECIMAL(13,4) DEFAULT 0.0,
    recieved_date TIMESTAMP DEFAULT NULL,
    quality_product provider_calification DEFAULT NULL,
    in_time provider_calification DEFAULT NULL,
    atention_calification provider_calification DEFAULT NULL,
    is_quantity_complete provider_calification DEFAULT NULL,
    FOREIGN KEY (id_buy_order) REFERENCES buy_orders(id),
    FOREIGN KEY (id_product) REFERENCES products(id)
);

CREATE TABLE service_orders(
    id BIGSERIAL PRIMARY KEY,
    id_provider BIGINT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    status orders_status DEFAULT 'PENDING',
    FOREIGN KEY (id_provider) REFERENCES providers(id)
);

CREATE TABLE service_order_items(
    id BIGSERIAL PRIMARY KEY,
    id_service_order BIGINT NOT NULL,
    id_product BIGINT NOT NULL,
    id_service BIGINT NOT NULL,
    quantity DECIMAL(13,4) DEFAULT 0.0,
    quantity_received DECIMAL(13,4) DEFAULT 0.0,
    recieved_date TIMESTAMP DEFAULT NULL,
    quality_product provider_calification DEFAULT NULL,
    in_time provider_calification DEFAULT NULL,
    atention_calification provider_calification DEFAULT NULL,
    is_quantity_complete provider_calification DEFAULT NULL,
    FOREIGN KEY (id_service_order) REFERENCES service_orders(id),
    FOREIGN KEY (id_product) REFERENCES products(id),
    FOREIGN KEY (id_service) REFERENCES services(id)
);

CREATE TABLE payments (
    id BIGSERIAL PRIMARY KEY,
    id_buy_order BIGINT NOT NULL,
    id_service_order BIGINT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT NULL,
    amount DECIMAL(11,2) DEFAULT 0.0,
    payment_method payment_method DEFAULT 'CASH',
    status payment_status DEFAULT 'PENDING',
    FOREIGN KEY (id_buy_order) REFERENCES buy_orders(id),
    FOREIGN KEY (id_service_order) REFERENCES service_orders(id)
);