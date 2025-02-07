import "./AdminMenu.css";

function AdminMenu() {
    return (
        <nav className="admin-menu">
            <ul>
                <li><a href="#">Dashboard</a></li>
                <li><a href="#">Brugere</a></li>
                <li><a href="#">Indstillinger</a></li>
                <li><a href="#">Log ud</a></li>
            </ul>
        </nav>
    );
}

export default AdminMenu;
