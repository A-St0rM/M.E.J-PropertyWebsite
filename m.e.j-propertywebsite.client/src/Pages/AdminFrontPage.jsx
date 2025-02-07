import "./Css/AdminFrontPage.css";
import AdminMenu from "../Componets/AdminMenu";

function AdminFrontPage() {
    return (
        <div className="admin-container">
            <header className="admin-header">M.E.J</header>
            <div className="admin-content">
                <AdminMenu />
                <main className="admin-main">
                    <p>Velkommen til adminpanelet!</p>
                </main>
            </div>
        </div>
    );
}

export default AdminFrontPage;